# Advent of Code 2025

Solutions for [Advent of Code 2025](https://adventofcode.com/2025) challenges, implemented in C# with .NET 8.0.

## Project Structure

```
src/advent.of.code-2025/
├── day01/             # Riddle Code of Day 01
│   ├── Dial.cs
│   ├── Lock.cs
│   └── ...
└── ...                # Additional days as completed
tests/advent.of.code-2025.tests/
├── day01/             # Riddle Code of Day 01
│   ├── TestInput.txt
│   ├── TestRotatingLock.cs
│   └── ...
└── ...                # Additional days as completed
```

## Technologies

- **Framework:** .NET 8.0
- **Language:** C# with implicit usings and nullable reference types enabled
- **Testing:** xUnit 2.5.3
- **Test Runner:** Microsoft.NET.Test.Sdk 17.8.0
- **Coverage:** Coverlet 6.0.0

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.net/download/dotnet/8.0) or later

### Building the Project

```bash
dotnet build
```

### Running Tests

Run all tests:
```bash
dotnet test
```

Run tests for a specific day:
```bash
dotnet test --filter "FullyQualifiedName~Day01"
```

Run with verbose output:
```bash
dotnet test --logger "console;verbosity=detailed"
```

### Running Solutions

The project is structured as a test project, so solutions are executed through their respective test methods. Look for test methods with `DisplayName = "Solution"` or similar markers.

## Completed Days

### Day 1: Secret Entrance
**Challenge:** Decode a safe's rotating dial to find the password based on how many times the dial points to zero.

**Key Concepts:**
- Circular dial mechanics (0-99)
- Left/Right rotation handling
- Modular arithmetic
- Zero-crossing detection

**Files:** `Day01/`

## Development Notes

- Each day's solution is contained in its own directory
- Unit tests validate the logic using the provided examples
- Puzzle inputs and test inputs are copied to the output directory during build
- Solutions follow TDD principles with comprehensive test coverage

## License

This is a personal project for educational purposes as part of the Advent of Code 2025 challenge.

## Acknowledgments

- [Advent of Code](https://adventofcode.com/) by [Eric Wastl](https://was.tl/)
