# https://www.tutorialspoint.com/genetic_algorithms
from Population import Population


class Problem:
    paramsPath = ""
    params = {}
    population = None

    def __init__(self, paramsPath):
        self.paramsPath = paramsPath
        self.loadParams()
        self.initialisePopulation()


    def loadParams(self):
        # Loads params into a dictionary
        file = open(self.paramsPath, "r")
        for line in file:
            if line[-1] == "\n":
                line = line[:-1]

            lineSplit = line.split(' ')
            self.params[lineSplit[0]] = lineSplit[1]

    def initialisePopulation(self):
        self.population = Population( int( self.params["population"] ) )


