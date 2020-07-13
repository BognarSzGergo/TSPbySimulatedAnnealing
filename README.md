# TSPbySimulatedAnnealing
 Solving traveling salesman problem with simulated annealing algorithm in C#
 
 (This project is a university assignment.)
 
 ## Travelling Salesman Problem
A salesman wants to travel to N cities (he should pass by each city).How can we order the cities so that the salesman’s journey will be the shortest? The objective function to minimize here is the length of the journey.
 ## Simulated Annealing
Simulated Annealing was given this name in analogy to the “Annealing Process” in thermodynamics, specifically with the way metal is heated and then is gradually cooled so that its particles will attain the minimum energy state. Then, the aim for a Simulated Annealing algorithm is to randomly search for an objective function. Simulated Annealing's advantage over other methods is the ability to obviate being trapped in local minima. In here, we mean that the algorithm does not always reject changes that decrease the objective function but also changes that increase the objective function according to its probability function: P = exp (-∆f/T) Where T is the control parameter and ∆f is the variation in the objective function.
