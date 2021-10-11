const Facts = [
    "Mars is 142 million miles from the sun",
    "Mars is 4,220 miles in diameter",
    "Mars is home to the largest mountain in the solar system",
    "There have been 18 successful missions to mars",
    "Mars has frozen water to this day",
    "Mars has two moons, one which will crash into Mars or rip appart in around 50 million years",
    "We have pieces of Mars on earth due to the low gravity of mars and astroids hitting mars, making debris go to earth"
];


const randomFact = Facts[Math.floor(Math.random() * Facts.length)];
document.getElementById("Facts").innerHTML = randomFact;