import mpmath


def reverse_n_pi_digits(n: int) -> str:
    mpmath.mp.dps = n
    return str(mpmath.pi / 10)[2:][::-1]
