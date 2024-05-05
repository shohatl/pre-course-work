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


if __name__ == '__main__':
    pythagorean_triplet_by_sum(0)
