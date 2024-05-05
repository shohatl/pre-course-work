def num_len(num: int) -> int:
    return num_len(num=int(num / 10)) + 1 if num > 10 else 1


if __name__ == '__main__':
    print(num_len(123456))
