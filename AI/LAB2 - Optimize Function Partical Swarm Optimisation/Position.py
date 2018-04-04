import random

class Position:
    len = 0
    vmin = 0
    vmax = 0
    dims = []

    def __init__(self, len, vmin, vmax):
        self.len = len
        self.vmin = vmin
        self.vmax = vmax
        self.initRandom()


    def initZero(self):
        self.dims = []
        for _ in range(self.len):
            self.dims.append(0)

    def initRandom(self):
        self.dims = []
        for _ in range(self.len):
            value = random.uniform(self.vmin, self.vmax)
            self.dims.append( value )

    def clear(self):
        self.dims = [ ]

    def addDimension(self, nr):
        nrClipped = nr
        if nrClipped < self.vmin:
            nrClipped = self.vmin
        if nrClipped > self.vmax:
            nrClipped = self.vmax

        if len(self.dims) < self.len :
            self.dims.append( nrClipped )

    def __str__(self):
        return str(self.dims[0]) + " - " + str(self.dims[1])