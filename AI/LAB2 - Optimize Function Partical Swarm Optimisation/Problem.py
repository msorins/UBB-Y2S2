class Problem:
    paramsPath = ""
    params = {}

    def __init__(self, paramsPath):
        self.paramsPath = paramsPath
        self.loadParams()

    def loadParams(self):
        # Loads params into a dictionary
        file = open(self.paramsPath, "r")
        for line in file:
            if line[-1] == "\n":
                line = line[:-1]

            lineSplit = line.split(' ')
            self.params[lineSplit[0]] = lineSplit[1]