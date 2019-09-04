# -*- coding: utf-8 -*-
"""
Created on Wed Sep  4 10:02:42 2019

@author: jorpla
"""

import numpy as np

# 1. multiplicar una fila por un número diferente de cero
def RowOperation1(matrix, fila, factor):
    matrix[fila] = matrix[fila]*factor
    return matrix

# 2. Sumar un múltiplo de una fila a otra fila
def RowOperation2(matrix, filaTarget, filaSource, factor):
    matrix[filaTarget] = matrix[filaTarget] + (matrix[filaSource]*factor)
    return matrix

# 3. Intercambiar dos filas
def RowOperation3(matrix, fila1, fila2):
    tmp = np.array(matrix[fila2])
    matrix[fila2] =  matrix[fila1]
    matrix[fila1] =  tmp
    return matrix

A = np.array([[2,4,6],[4,5,6],[3,1,-2]], dtype=np.float64)
B = np.array([[18],[24],[4]], dtype=np.float64)
AB = np.concatenate((A, B), axis=1)
print(AB)

a = np.matrix('2,4,6;4,5,6;3,1,-2', dtype=np.float64)
b = np.matrix('18;24;4', dtype=np.float64)
ab = np.concatenate((a, b), axis=1)
print(ab)


ab = RowOperation1(ab,0,0.5)
print(ab)

ab = RowOperation2(ab,1,0,-4)
ab = RowOperation2(ab,2,0,-3)
print(ab)

ab = RowOperation1(ab,1,-1/3)
print(ab)

ab = RowOperation2(ab,0,1,-2)
ab = RowOperation2(ab,2,1,5)
print(ab)

ab = RowOperation1(ab,2,-1)
print(ab)

ab = RowOperation2(ab,0,2,1)
ab = RowOperation2(ab,1,2,-2)
print(ab)

ab = RowOperation3(ab,0,2)
print(ab)

