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
