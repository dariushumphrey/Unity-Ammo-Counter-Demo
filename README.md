# Unity Ammo Counter - Demo
https://github.com/user-attachments/assets/023b58c8-5bba-48f4-88cf-b8cd8d4c4f02

# Explanation
For the ammo counter to report the rifle's current ammo, a string is assigned the numerical ammo value, and is parsed using two char variables representing the left and right digits. The char values are subtracted by '0' to retrieve the integer numbers. Two integer values (left and right) are assigned these numbers, and are used to index an array of numbered materials (0-9) and apply that number to the ammo counter. In effect, the weapon's literal current ammunition is used to find and apply the correct numbers.
 * The string is formatted with a leading zero ("0#"), avoiding errors for when the current magazine count becomes a single digit.

```csharp
public void AmmoCounterRead()
{
    ammoReadConvert = currentAmmo.ToString("D2");
    leftIndexChar = ammoReadConvert[0];
    rightIndexChar = ammoReadConvert[1];

    leftIndex = leftIndexChar - '0';
    rightIndex = rightIndexChar - '0';

    arMaterials[4] = ammoCounterNumbers[leftIndex];
    arMaterials[6] = ammoCounterNumbers[rightIndex];
    assaultRifle.materials = arMaterials;
}
```

## Auxiliary Systems
* **Weapon recoil** - Firing the rifle instantly recoils it backwards, pulling it to a resting position when no longer in use.
* **Weapon reticle** - The rifle's inner reticle expands to simulate a spreading shot pattern while firing, and shrinks when it stops firing.
* **Motion Tracker** - The tracker is a cosmetic UI element that loops through an array of sprites to animate an outward detection pulse.
