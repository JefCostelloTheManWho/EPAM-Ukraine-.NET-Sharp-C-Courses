function getRandomIntInclusive(min, max) {
	min = Math.ceil(min);
	max = Math.floor(max);
	return Math.floor(Math.random() * (max - min + 1)) + min;
}

class Fighter {
	constructor(prop) {

		let _hp = prop.hp;
		let _win = 0;
		let _loss = 0;
		
		this.getName = function() { return prop.name; }

		this.getDamage = function() { return prop.damage; }

		this.getStrength  = function() { return prop.strength; }

		this.getAgility = function() { return prop.agility; }

		this.getInitialHealth = function() { return prop.hp; }

		this.getHealth = function() { return _hp; }

		this.setHealth = function(heal) { _hp += heal; }

		this.getWins = function() { return _win; }

		this.setWins = function(win) { _win  += win; }

		this.getLoses = function() { return _loss; }

		this.setLoses = function(loss) { _loss += loss; }


	}
	
	attack(fighter) {
		const chance = 100 - fighter.getAgility() - fighter.getStrength();
		const success = getRandomIntInclusive(0, 100);
		if (success >= chance) {
			fighter.setHealth(-this.getDamage())
		if (fighter.getHealth() <= 0) {
			this.addWin();
			fighter.addLoss();
		}
		return console.log(`${this.getName()} makes ${this.getDamage()} damage to ${fighter.getName()}`);
		} else {
			return console.log(`${fighter.getName()} attack missed`);
		}
	}
	heal(hp) {
		this.setHealth(hp);
	}
	dealDamage(hp) {
		this.setHealth(-hp);
		if (this.getHealth() <= 0) {
			this.setHealth(Math.abs(this.getHealth()))
			this.addLoss();
		}
	}
	addWin() {
		 this.setWins(1);
	}
	addLoss() {
	   	 this.setLoses(1);
	}
	logCombatHistory() {
		return console.log(`Name:${this.getName()},Wins:${this.getWins()},Losses:${this.getLoses()}`);
	}
}
function battle(fighter1, fighter2) {
	if(comp(fighter1, fighter2)){
		return `${fighter1.getName()} can't fight with himself`;
	}
	if (fighter2.getHealth() === 0) {
		console.log(`${fighter2.getName()} is dead`);
		return 0;
	}
	if (fighter1.getHealth() === 0) {
		console.log(`${fighter1.getName()} is dead`);
		return 0;
	}
	const IsFighting = true; 
	while (IsFighting) {
		fighter1.attack(fighter2);
		if (fighter2.getHealth() === 0) {
			console.log(`${fighter1.getName()}) has won!`); 
			return fighter2;
		}
		fighter2.attack(fighter1);
		if (fighter1.getHealth() === 0) {
			console.log(`${fighter2.getName()} has won!`); 
			return fighter1;
		}
		fighter2.attack(fighter1);
		if (fighter1.getHealth() === 0) {
			console.log(`${fighter2.getName()} has won!`); 
			return fighter1;
		}
	}
}
function comp(f1, f2){
	let isEqual = false;
	if(f1 === f2) {
		isEqual = true; 
	}
	return isEqual;
}
module.exports = { Fighter, battle};
