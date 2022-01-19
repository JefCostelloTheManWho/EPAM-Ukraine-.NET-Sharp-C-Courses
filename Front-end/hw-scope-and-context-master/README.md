# Scope and context
## TASK № 1
1) Create a Fighter


You should create a function or class ‘Fighter’ which takes an object with fighter properties and returns interface with fighter's methods:  

`const myFighter = new Fighter({name: ‘Maximus, damage: 20, hp: 100, strength: 30, agility: 25});` // returns an object with methods  

!!!Note that none of the Fighter’s properties may be available directly. The only way to get or change each property is to use one of Fighter’s methods!!!  
 For example:
```
let name = myFighter.name;  
console.log(name); // undefined  
```


**Fighter methods:**  

**getName**. 
This function returns fighter’s name property. 
 For example:
```
let name = myFighter.getName();  
console.log(name); // Maximus  
```


**getDamage**. This function returns fighter’s damage property.  
For example:
```
let damage = myFighter.getDamage();  
console.log(damage); // 20
```
  

**getStrength**. This function returns fighter’s strength property.  
	let strength = myFIghter.getStrength();  
	console.log(strength); // 30  

**getAgility**.
This function returns fighter’s agility property.  
```
let agility = myFighter.getAgility();  
console.log(agility); // 25  
```


**getHealth**. 
This function returns fighter’s current HP property.  
```
let health = myFighter.getHealth();  
console.log(health); // 100 
```
 

**attack**.
This function takes argument (instance of ‘Fighter’), which will be a defender. 
Then it randomly calculates if current attack is successful .

- In your attack method create a variable isSuccessful 
- create a function which returns a random number from 0 to 100 
- `const isSuccessful= random()`.
- check whether the sum of defender's agility and strength(health) is more than the success number.
- If it is more than defender misses the attack 
and a message "<Figter's name> attack missed" should be logged to the console
Note! For example:
'Sasha attack missed' --- This string should be logged. This string means that Sasha missed John's attack and his hp property remained the same

- If attack is successful, defenders’ current HP property is decreased by number of points equal to attacker’s damage property and
message about successful attack is logged in console. Otherwise, message about missed attack is logged.. For example :
'John makes 25 damage to Sasha' --- This string should be logged. This string means that Sasha's hp property decreased by 25

```
myFighter.attack(myFighter2);  
// Maximus makes 20 damage to Commodus  
myFighter2.attack(myFighter);  
// Commodus attack missed 

const fighter1=new Fighter({name: 'John', damage: 25, hp: 105, strength: 30, agility: 40});
const fighter2 = new Fighter({name: 'Sasha', damage: 45, hp: 100, strength: 30, agility: 25});
fighter2.attack(fighter1)//'Sasha attack missed'
fighter1.attack(fighter2)//'John makes 25 damage to Sasha'
```
 

**logCombatHistory**. This function logs to console information about fighter’s combat
history.  
### For example:
`myFighter.logCombatHistory(); // Name:Maximus,Wins:0,Losses:0` (Note! NO whitespace) 

**heal**. This function takes amount of health points and add this amount to fighter’s current
HP 
### For example:

`myFighter.heal(50);`

**dealDamage**. This function takes amount of health points and reduces these amount from fighter’s current HP (if it results to a negative number, current HP should equal 0):  
### For example:
`myFighter.dealDamage(20);`

**addWin**. This function increases fighter’s wins property by one.
### For example:
`myFighter.addWin();`

**addLoss**. This function increases fighter’s losses property by one.  
`myFighter.addLoss();`

**2) Create a ‘battle’ function:**  
1. This function takes 2 arguments (instances of ‘Fighter’)  and simulates battle between them.
2. While 1st and 2nd fighters' **hp** is more than 0  perform attacks.
3. After that it logs the message with the name of the winner and **increases winner’s ‘wins’ property and loser’s ‘losses’ property by one.**


If at the start of battle one of given fighter’s is dead (his HP is equal to 0):
- the funtion shoud log '<fighter's name> is dead' and return 0
- battle shouldn’t be simulated 

If there are 2 losers:

- the function should return 0(There may be a case when Both of them attack at the same time
and their health scores then are equal to 0)

If there is 1 loser :
- the function should **return the loser **
- log to the console information about the winner, a string '<fighter's name> has won!' 





**EXAMPLE 1**

const fighter1=new Fighter({name: 'Maximus', damage: 25, hp: 105, strength: 30, agility: 40});
const fighter2 = new Fighter({name: 'David', damage: 15, hp: 0, strength: 10, agility: 10});

battle(fighter1,fighter2) // 'David is dead'

**Example 2**


```
const fighter1=new Fighter({name: 'John', damage: 25, hp: 105, strength: 30, agility: 40});
const fighter3 = new Fighter({name: 'Alex', damage: 35, hp: 200, strength: 30, agility: 25});
```


**battle(fighter1,fighter3)
//In the Console **



```
John makes 25 damage to Alex
Alex makes 35 damage to John
John attack missed
Alex attack missed
John attack missed
Alex attack missed
John makes 25 damage to Alex
Alex attack missed
John attack missed
Alex makes 35 damage to John
John makes 25 damage to Alex
Alex makes 35 damage to John
John attack missed
Alex attack missed
John makes 25 damage to Alex
Alex makes 35 damage to John
John makes 25 damage to Alex
Alex attack missed
John attack missed
Alex attack missed
John attack missed
Alex attack missed
John attack missed
Alex attack missed
John attack missed
Alex attack missed
John attack missed
Alex attack missed
John attack missed
Alex attack missed
John makes 25 damage to Alex
Alex attack missed
John makes 25 damage to Alex
Alex attack missed
John makes 25 damage to Alex
Alex attack missed

```
In this example by the end of the battle 
alex's hp = john's hp =0


**OR EXAMPLE 3**


```
John attack missed
John attack missed
Alex attack missed
John attack missed
Alex attack missed
John attack missed
Alex attack missed
John attack missed
Alex attack missed
John makes 25 damage to Alex
Alex makes 35 damage to John
John attack missed
Alex attack missed
John makes 25 damage to Alex
Alex attack missed
John makes 25 damage to Alex
Alex attack missed
John makes 25 damage to Alex
Alex attack missed
John attack missed
Alex makes 35 damage to John
John attack missed
Alex attack missed
John makes 25 damage to Alex
Alex attack missed
John attack missed
Alex attack missed
John attack missed
Alex attack missed
John attack missed
Alex attack missed
John attack missed
Alex attack missed
John makes 25 damage to Alex
Alex attack missed
John attack missed
Alex attack missed
John attack missed
Alex attack missed
John makes 25 damage to Alex
Alex attack missed
John makes 25 damage to Alex
Alex attack missed
John has won!

```



