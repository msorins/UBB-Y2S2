import math

import copy

from Position import Position


class Particle:
    # Number of dimensions of search space
    len = 0

    # Search space boundaries
    vmin = 0
    vmax = 0

    # Will contain a Position object that has len dimensions
    position = None
    fitness = 0
    velocity = None

    # Memory of the best fitnes ( better is lower )
    bestFitness = 999999999
    bestPosition = None

    def __init__(self, len, vmin, vmax, position = None, velocity = None):
        self.len = len
        self.vmin = vmin
        self.vmax = vmax

        # Position
        if position == None:
            self.position = Position(len, vmin, vmax)
        else:
            self.position = position

        # Velocity
        if velocity == None:
            self.velocity = Position(len, vmin, vmax)
        else:
            self.velocity = velocity

        # Set up the best fitness & best position
        self.evaluate()
        self.bestFitness = self.fitness
        self.bestPosition = copy.deepcopy(self.position)

    def computeFitness(self):
        x = self.position.dims[0]
        y = self.position.dims[1]

        firstSum = x ** 2.0 + y ** 2.0
        secondSum = math.cos(2.0 * math.pi * x) + math.cos(2.0 * math.pi * y)

        return (-20.0 * math.exp(-0.2 * math.sqrt(firstSum / 2)) - math.exp(secondSum / 2) + 20 + math.e)

    def evaluate(self):
        self.fitness = self.computeFitness()
        return self.fitness

    def update(self, newPosition):
        self.position = newPosition

        self.evaluate()
        if self.fitness < self.bestFitness:
            self.bestFitness = self.fitness
            self.bestPosition = copy.deepcopy( self.position )