import time

def add(a, b):
    print(f"Adding {a} + {b}")
    return a + b

def slow_add(a, b):
    print("Starting slow add...")
    time.sleep(5)
    print("Done.")
    return a + b

def fail_example():
    raise Exception("This is an intentional Python error.")

print("Math operations script loaded.")

