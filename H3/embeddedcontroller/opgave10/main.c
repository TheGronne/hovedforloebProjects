#include <stdio.h> 
#include "io430.h"
#include <math.h>

int main( void )
{
  // ----- Opgave 1 ------
  
  // Stop watchdog timer to prevent time out reset
  WDTCTL = WDTPW + WDTHOLD;

  float tabel[ ]={165,165,165,165,165,165,165,165,175,175,175,175,175,
                  175,175,175,175,175,175,185,185,185,185,185,185};
  int i = 0;
  double result = 0.0;
  while(i < 25){
    result += tabel[i];
    i += 1;
  }
  printf("Sum: %f\n", result);
  
  
  double middel = result/25.0;
  printf("m: %f\n", middel);
  
  
  i = 0;
  result  = 0;
  double varians = 0;
  double toThePowerOfOne = 0;
  double toThePowerOfTwo = 0;
  while(i < 25){
    toThePowerOfOne = 0;
    toThePowerOfOne = (middel - tabel[i]);
    toThePowerOfTwo = toThePowerOfOne * toThePowerOfOne;
    result += toThePowerOfTwo;
    i += 1;
  }
  varians = result/25;
  printf("v: %f\n", varians);
  
  
  double spredning = 0;
  spredning = sqrt(varians);
  printf("s: %f\n", spredning);
  
  //----- Opgave 2 -----
  WDTCTL = WDTPW + WDTHOLD; // Stop watchdog timer to prevent time out reset
  
  ADC12CTL0 &= ~ADC12ENC; // Make sure that the ADC is off
  
  ADC12CTL0 = ADC12SHT02 + ADC12ON; // Enable the ADC.
  
  ADC12CTL1 = ADC12SHP; 
  
  ADC12MCTL0 = ADC12INCH_0; // Assigns memory destination.
  
  ADC12CTL0 |= ADC12ENC; // Turn on adc
  
  
  TA0CCR0 = 500; // PWM Period
  
  TA0CCTL1 = OUTMOD_7; // Output mode to Set/Reset

  TA0CCR1 = 50; // PWM Duty Cycle
  
  TA0CTL = TASSEL_1 + MC_1; // ACKL, upmode
  
  P6SEL |= BIT0; // P6.0 - Select ADC
  P1DIR |= BIT2; // P1.2 - Set as output
  P1SEL |= BIT2; // P1.2 - Select TA1
  
  float array[] = {0,0,0,0,0};
  i = 0;
  while(i < 5)
  {
    ADC12CTL0 |= ADC12SC; // Start sampling
    
    while( ADC12CTL1 & ADC12BUSY ); // Wait for the ADC to finish sampling.
    
    float result = ADC12MEM0;
    
    array[i] = result;
    printf("Array: %f\n", array[i]);
    i += 1;
  }
}