import math
import random

class Individ:
    # _x, _y numbers between [0, 1000]
    _x = 0
    _y = 0
    nrBits = 14

    def __init__(self, x = None, y = None):
        """
        :param x: real number [-5, 5] with 2 digits
        :param y: real number [-5, 5] with 2 digits
        """
        if x != None and y != None:
            if type(x) is int:
                self.setX(x)
            if type(y) is int:
                self.setY(y)

            if type(x) is str:
                self.setXFromBinary(x)

            if type(y) is str:
                self.setYFromBinary(y)
        else:
            newX = ''
            newY = ''

            for i in range(self.nrBits):
                prob = random.random()
                if prob <= 0.5:
                    newX += '0'
                else:
                    newX += '1'

            for i in range(self.nrBits):
                prob = random.random()
                if prob <= 0.5:
                    newY += '0'
                else:
                    newY += '1'

            self.setXFromBinary(newX)
            self.setYFromBinary(newY)


    def getX(self):
        """
        :return: x, number between [0, 1000]
        """
        return self._x

    def getY(self):
        """
        :return: y, number between [0, 1000]
        """
        return self._y

    def getUnconvertedX(self):
        """
        :return: x, real number between [-5, 5]
        """
        return self._x / 100 - 5

    def getUnconvertedY(self):
        """
        :return: y, real number between [-5, 5]
        """
        return self._y / 100 - 5

    def getBinaryX(self):
        """
         :return: x, string of 14 chars, binary representation of _x
        """
        res = ''
        aux = '{0:14b}'.format(self._x)
        for c in aux:
            if c == ' ':
                res += '0'
            else:
                res += c
        return res

    def getBinaryY(self):
        """
            :return: x, string of 14 chars, binary representation of _x
        """
        res = ''
        aux = '{0:14b}'.format(self._y)
        for c in aux:
            if c == ' ':
                res += '0'
            else:
                res += c
        return res

    def setX(self, x):
        """
        :param x: real number [-5, 5]
        """
        self._x = (x + 5) * 100

    def setY(self, y):
        """
        :param x: real number [-5, 5]
        """
        self._y = (y + 5) * 100

    def setXFromBinary(self, x):
        """
        :param x:
        :return:
        """
        self._x = int(x, 2)

    def setYFromBinary(self, y):
        """
        :param y:
        :return:
        """
        self._y = int(y, 2)

    def fitness(self):
        x = self.getUnconvertedX()
        y = self.getUnconvertedY()

        firstSum = x ** 2.0 + y ** 2.0
        secondSum = math.cos(2.0 * math.pi * x) + math.cos(2.0 * math.pi * y)

        return -20.0 * math.exp(-0.2 * math.sqrt(firstSum / 2)) - math.exp(secondSum / 2) + 20 + math.e

    def mutate(self, p):
        """
        :param p: probability, real [0, 1]
        :return: a new individ that could have a mutation
        """
        x = self.getBinaryX()
        y = self.getBinaryY()

        newX = ''
        newY = ''
        for c in x:
            prob = random.random()

            if prob < p:
                newX += str( 1 - int(c) )
            else:
                newX += c

        for c in y:
            prob = random.random()
            if prob < p:
                newY += str( 1 - int(c) )
            else:
                newY += c


        return Individ(newX, newY)

    def crossover(self, otherIndivid):
        return self.uniformCrossover(otherIndivid)
        #return self.onePointCrossover(otherIndivid)

    def uniformCrossover(self, otherIndivid):
        """
        :param otherIndivid: the other individ to to the mutation with
        :param p: probability, real [0, 1]
        :return:
        """
        selfX = self.getBinaryX()
        selfY = self.getBinaryY()

        otherX = otherIndivid.getBinaryX()
        otherY = otherIndivid.getBinaryY()

        newXOne = ''
        newYOne = ''

        newXTwo = ''
        newYTwo = ''

        for i in range( self.nrBits ):
            prob = random.random()
            if prob <= 0.5:
                newXOne += selfX[i]
                newXTwo += otherX[i]
            else:
                newXOne += otherX[i]
                newXTwo += selfX[i]

        for i in range( self.nrBits ):
            prob = random.random()
            if prob <= 0.5:
                newYOne += selfY[i]
                newYTwo += otherY[i]
            else:
                newYOne += otherY[i]
                newYTwo += selfY[i]

        return Individ(newXOne, newYOne), Individ(newXTwo, newYTwo)

    def onePointCrossover(self, otherIndivid):
        splitPos = random.randint(1, 13)

        selfX = self.getBinaryX()
        selfY = self.getBinaryY()

        otherX = otherIndivid.getBinaryX()
        otherY = otherIndivid.getBinaryY()

        newXOne = selfX[:splitPos] + otherX[splitPos:]
        newYOne = selfY[:splitPos] + otherY[splitPos:]

        newXTwo = selfX[splitPos:] + otherX[:splitPos]
        newYTwo = selfY[splitPos:] + otherY[:splitPos]

        return Individ(newXOne, newYOne), Individ(newXTwo, newYTwo)
