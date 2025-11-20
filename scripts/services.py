import json

def inspect(obj):
    """Inspect an object and return its attributes and methods."""
    gui_service('inspect', json.dumps(obj))


def parse_cobol(obj):
    """Parse a cobol file and return its AST."""
    return parser_service('parse_cobol', json.dumps(obj))
