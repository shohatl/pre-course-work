import matplotlib.pyplot as plt
from scipy.stats import pearsonr


def main():
    nums = []
    sum = 0
    positive_num = 0

    while True:
        num = float(input("Enter a num, -1 to end"))
        if num == -1:
            break
        if num > 0:
            positive_num += 1
        sum += num
        nums.append(num)

    print(f"the average is:{sum / len(nums)}")
    print(f"there are {positive_num} positive numbers")
    print("you entered the numbers:")
    sorted_nums = nums.copy()
    sorted_nums.sort()
    print(",".join(map(str, sorted_nums)))

    # bonus questions
    plt.plot(nums, "ro")
    plt.show()

    pearson_corr, _ = pearsonr(nums, range(len(nums)))
    print("the pearson correlation coefficient is: ", pearson_corr)


if __name__ == '__main__':
    main()
