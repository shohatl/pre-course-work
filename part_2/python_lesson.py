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


if __name__ == '__main__':
    print(is_sorted_polyndrom("lbcdgdcbl"))
