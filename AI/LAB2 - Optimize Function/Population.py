from Individ import Individ


class Population():
    lst = []

    def __init__(self, n, lst = None):
        """
        Initialise a population
        :param n:
        :param lst:
        :return:
        """
        if lst != None:
            self.lst = lst
        else:
            for i in range(n):
                self.lst.append(Individ())

    def evaluate(self):
        totalFitness = 0
        for individual in self.lst:
            totalFitness += individual.fitness()

        avgFitness = totalFitness / len(self.lst)
        return avgFitness

    def selection(self):
        sortedInd = sorted(self.lst, key = lambda x: x.fitness(), reverse = False)

        return sortedInd[ : len(self.lst) // 2 ]

