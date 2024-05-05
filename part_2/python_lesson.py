import matplotlib.pyplot as plt
from scipy.stats import pearsonr

def num_len(num: int) -> int:
    return num_len(num=int(num / 10)) + 1 if num > 10 else 1


def pythagorean_triplet_by_sum(sum: int):
    if sum <= 0:
        raise ValueError("sum must be bigger than 0")
    for a in range(1, int(sum / 2) + 1):
        for b in range(a, int((sum - a) / 2) + 1):
            c = sum - b - a
            if pow(c, 2) == pow(a, 2) + pow(b, 2):
                nums = [a, b, c]
                nums.sort()
                print("<".join(map(str, nums)))


def is_sorted_polyndrom(string: str) -> bool:
    if string != string[::-1]:
        return False
    x = len(string)
    x = int(x / 2) + x % 2
    string = string.lower()
    last = ord(string[0])
    for char in string[1:x]:
        if ord(char) >= last:
            last = ord(char)
        else:
            return False
    return True


def question_4():
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
    question_4()
