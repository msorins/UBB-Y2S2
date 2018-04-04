from Individ import Individ
import matplotlib.pyplot as plt
import numpy as np

class Algorithm:
    totalEpochs = 0
    crtEpoch = 0
    historyPopEval = []

    def __init__(self, problem):
        self.problem = problem
        self.totalEpochs = int(self.problem.params['epochs'])
        self.run()

    def run(self):
        while self.crtEpoch < self.totalEpochs:
            self.computeEpoch()
            self.crtEpoch += 1

        self.showStatistics()
        self.showEvalDiagram()

    def computeEpoch(self):
        mutationProbability = float(self.problem.params['mutation'])
        # 0 Evaluation
        print("Epoch " + str(self.crtEpoch) + ", eval: " + str( self.problem.population.evaluate() ))
        self.historyPopEval.append( self.problem.population.evaluate() )

        # 1 SELECTION
        selection = self.problem.population.selection()
        print("Best individ fitness: " + str( selection[0].fitness() ))
        print("Best invidivid coordinates: " + str( selection[0].getUnconvertedX() ) + ", " + str( selection[0].getUnconvertedY() ))

        kids = []
        for i in range(len(selection) - 1):
            # 2 CROSSOVER
            kid1, kid2 = selection[i].crossover(selection[i + 1])

            # 3 MUTATION
            kids.append( kid1.mutate( mutationProbability ) )
            kids.append( kid2.mutate( mutationProbability ) )

        kids.append( Individ() )
        kids.append( Individ() )

        # 4 REPLACE THE POPULATION WITH THE KIDS
        self.problem.population.lst = kids

        print("\n\n")

    def showEvalDiagram(self):
        indexes = list(range(0, len(self.historyPopEval)))

        plt.plot(indexes, self.historyPopEval)
        plt.show()

    def showStatistics(self):
        fitnessVector = []
        for pop in self.problem.population.lst:
            fitnessVector.append( pop.fitness() )

        print("MEAN: " + str( np.mean(fitnessVector) ))
        print("STD: " + str( np.std(fitnessVector) ))