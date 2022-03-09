#include "io430.h"
#include <stdio.h>

#define max_adc 4096.0;

int main( void )
{
  WDTCTL = WDTPW + WDTHOLD; // Stop watchdog timer to prevent time out reset
  
  ADC12CTL0 &= ~ADC12ENC; // Make sure that the ADC is off
  
  ADC12CTL0 = ADC12SHT02 + ADC12ON; // Enable the ADC.
  
  ADC12CTL1 = ADC12SHP; 
  
  ADC12MCTL0 = ADC12INCH_0; // Assigns memory destination.
  
  ADC12CTL0 |= ADC12ENC; //Turn on the adc
  
  
  TA0CCR0 = 500; // PWM Period
  
  TA0CCTL1 = OUTMOD_7; // Output mode to Set/Reset

  TA0CCR1 = 50; // PWM Duty Cycle
  
  TA0CTL = TASSEL_1 + MC_1; // ACKL, upmode
  
  P6SEL |= BIT0; // P6.0 - Select ADC
  P1DIR |= BIT2; // P1.2 - Set as output
  P1SEL |= BIT2; // P1.2 - Select TA1
  
  
  while(1)
  {
    ADC12CTL0 |= ADC12SC; // Start sampling
    
    while( ADC12CTL1 & ADC12BUSY ); // Wait for the ADC to finish sampling.
    
    float result = ADC12MEM0 / max_adc; //The result is 0 - 4096, dividing it with 4096 gives us a number between 0 and 1 aka percent
    
    int PWM = result * 500; // Calculates PWM duty cycle
    
    TA0CCR1 = PWM; // Set the duty cycle to our calculated value.
  }
}