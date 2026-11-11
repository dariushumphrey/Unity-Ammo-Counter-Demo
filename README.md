# Unity-Ammo-Counter-Demo
A presentation about ammo an counter reporting current ammunition through materials.

# Demo
https://github.com/user-attachments/assets/023b58c8-5bba-48f4-88cf-b8cd8d4c4f02

# Explanation
For the ammo counter to report the rifle's current ammo, a string is assigned the numerical ammo value, and is parsed using two char variables representing the left and right digits. The char values are subtracted by '0' to retrieve the integer numbers. Two integer values (left and right) are assigned these numbers, and are used to index an array of numbered materials (0-9) and apply that number to the ammo counter. In effect, the weapon's literal current ammunition is used to find and apply the correct numbers.
 * The string is given a leading zero ("0#") when the current magazine count becomes a single digit.
