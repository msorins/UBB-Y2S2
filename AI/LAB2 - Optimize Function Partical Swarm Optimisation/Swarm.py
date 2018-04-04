from Particle import Particle
import random

class Swarm:
    particles = []
    swarmSize = 0

    # Options
    nrDims = 0
    vmin = 0
    vmax = 0

    def __init__(self, swarmSize, nrDims, vmin, vmax, particles = None):
        self.swarmSize = swarmSize
        self.nrDims = nrDims
        self.vmin = vmin
        self.vmax = vmax

        if particles != None:
            self.particles = particles
        else:
            # Initialise the particles randomly
            for _ in range(swarmSize):
                self.particles.append( Particle(self.nrDims, self.vmin, self.vmax) )

    def getBestParticle(self):
        bestParticle = self.particles[0]

        for i in range(1, len(self.particles) ):
            if self.particles[i].fitness < bestParticle.fitness:
                bestParticle = self.particles[i]

        return bestParticle

    def evalSwarm(self):
        fitn = 0
        for part in self.particles:
            fitn += part.fitness

        return fitn / len(self.particles)

    def reinitialisation(self, pReinit):
        for i in range( len(self.particles) ):
            p = random.random()
            if p <= pReinit:
                self.particles[i] = Particle(self.nrDims, self.vmin, self.vmax)