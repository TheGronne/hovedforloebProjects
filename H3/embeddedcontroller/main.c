#include <stdio.h> 
#include "io430.h"
#include <math.h>
int main( void )
{
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
}
