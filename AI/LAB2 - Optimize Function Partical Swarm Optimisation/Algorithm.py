from random import random
import matplotlib.pyplot as plt
from Position import Position
from Swarm import Swarm
import numpy as np

class Algorithm:
    problem = None
    swarm = None

    crtIteration = 0
    totalIterations = 0

    #params
    w = 0
    c1 = 0
    c2 = 0

    #
    historySwarmEval = []

    def __init__(self, problem):
        self.problem = problem
        self.swarm = Swarm(  int( self.problem.params["swarmSize"] ),
                             int( self.problem.params["nrDims"] ),
                             int( self.problem.params["vmin"] ),
                             int( self.problem.params["vmax"] )
                           )
        self.totalIterations =  int( self.problem.params["totalIterations"] )
        self.w =  float ( self.problem.params["w"] )
        self.c1 = float ( self.problem.params["c1"] )
        self.c2 = float ( self.problem.params["c2"] )

        self.run()
        self.showStatistics()
        self.showEvalDiagram()

    def run(self):
        while self.crtIteration < self.totalIterations:
            # Log & history stuff
            print("Iteration: " + str(self.crtIteration))
            print("BestParticle fit: " + str(self.swarm.getBestParticle().fitness))
            print("BestParticle pos: " + str(self.swarm.getBestParticle().position))
            print("\n\n")
            self.historySwarmEval.append( self.swarm.evalSwarm() )

            self.iteration()
            self.reinitialisation()
            self.crtIteration += 1

    def iteration(self):
        # Update each particle's velocity & position
        bestParticle = self.swarm.getBestParticle()

        # Iterate through each particle -> UPDATE VELOCITIES
        for i in range( len(self.swarm.particles) ):
            crtParticle = self.swarm.particles[i]

            # Iterate through each dimension
            for j in range(crtParticle.len):
                newVelocity = self.w * crtParticle.velocity.dims[j]
                newVelocity = newVelocity + self.c1 * random() * (bestParticle.position.dims[j] - crtParticle.position.dims[j])
                newVelocity = newVelocity + self.c2 * random() * (crtParticle.bestPosition.dims[j] - crtParticle.position.dims[j])
                crtParticle.velocity.dims[j] = newVelocity

        # Iterate through each particle -> UPDATE POSITIONS
        for i in range(len(self.swarm.particles)):
            crtParticle = self.swarm.particles[i]
            newPos = Position(int( self.problem.params["nrDims"] ),
                             int( self.problem.params["vmin"] ),
                             int( self.problem.params["vmax"] ))
            newPos.clear()

            # Iterate through each dimension
            for j in range(crtParticle.len):
                newPos.addDimension( crtParticle.position.dims[j] + crtParticle.velocity.dims[j] )

            crtParticle.update(newPos)

    def showEvalDiagram(self):
        indexes = list(range(0, len(self.historySwarmEval)))

        plt.plot(indexes, self.historySwarmEval)
        plt.show()

    def reinitialisation(self):
        probReinitialisation = float ( self.problem.params["probReinit"] )
        self.swarm.reinitialisation(probReinitialisation)

    def showStatistics(self):
        fitnessVector = []
        for particle in self.swarm.particles:
            fitnessVector.append( particle.fitness )

        print("MEAN: " + str( np.mean(fitnessVector) ))
        print("STD: " + str( np.std(fitnessVector) ))

