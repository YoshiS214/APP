import sys

if __name__ == '__main__':
    if len(sys.argv) == 3:
        firstArgument = int(sys.argv[1]) 
        secondArgument = int(sys.argv[2])
        print(firstArgument + secondArgument)
    else:
        print('ArgumentException...')