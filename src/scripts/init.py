import json

def inspect(obj):
    """Inspect an object and return its attributes and methods."""
    gui_service('inspect', json.dumps(obj))

