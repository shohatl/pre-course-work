def num_len(num: int) -> int:
    return num_len(num=int(num / 10)) + 1 if num > 10 else 1
