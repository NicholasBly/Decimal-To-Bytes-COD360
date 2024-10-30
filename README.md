# Decimal-To-Bytes-COD360
An interesting way of converting a number with 3 decimal places to PowerPC memory.

I found this project to be very fun and interesting on how an Xbox 360 game stores decimal values in memory. Normally, Xbox 360 games stores values in Little/Big Endian formats, however this specific example uses per-byte values that must add up to the end result.

We have a virtual address that accepts 4 bytes of memory to read a value into the game to display a ratio between both kills/deaths (KD Ratio) and wins and losses (WL Ratio). The number is formatted with up to 3 decimal places.

Each byte represents a different number, meaning the first, second, third, and fourth bytes are all unique. 

The function CalculateBytes I wrote handles the logic of each of these byte values. When a user submits a value, for example 1.525, we have to check whether the value is equal to or greater than the value that each byte represents when writing "01".

In backwards order, the 4th byte represents large numbers, with memory value 01 equalling 65.536. The 3rd byte represents 0.226, and the 2nd byte represents 0.001. The first byte is unused.

In order to solve this equation, we must check the user's value with each byte in decending order. We check if our example value is larger than or equal to 65.536; if not, we skip writing to that byte entirely.

The next value to check is byte 3, which does satisfy being able to store 1.525, because it is larger than 0.256. Now, we just need to divide 1.525 by 0.256 and store that in the byte array.

Because byte 3 cannot accurately represent our number with just one byte (1.525 is not divisible by 0.256), byte 2 must store the remainder. Because memory value 01 represents 0.001, we can use the remaining amount to fine-tune to get to exactly 1.525.

End result: bytes 00, F5, 05, 00 represents the decimal value 1.525. If we take F5, which is 0.245, and add it with 05, which is 1.28, we get 1.525.
