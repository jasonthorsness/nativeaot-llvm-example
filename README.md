## A NativeAOT-LLVM Example

This project demonstrates compiling a C# application with a C helper to a WASM module and basic loading and interaction. This is a bare-bones example to demonstrate the tool chain.

What is NativeAOT-LLVM? [Check it out](https://github.com/dotnet/runtimelab/tree/feature/NativeAOT-LLVM).

## To Run

### 1 Install dotnet 8 and python 3

Use the appropriate installers for these products.

### 2 Set Up EMSDK

See https://emscripten.org/docs/getting_started/downloads.html - note that the SDK is already present in the 'emsdk' folder in this repo. "Install" and "Activate" EMSDK.

For example (might differ on your machine):

```
.\emsdk\emsdk.bat install latest
.\emsdk\emsdk.bat activate latest
```

### 3 Build and Publish

Run the following:

```
dotnet publish -r browser-wasm -c Release /p:MSBuildEnableWorkloadResolver=false --self-contained /p:NativeDebugSymbols=false /p:EmccExtraArgs="-s EXPORTED_FUNCTIONS=""[_Answer]"" -s EXPORTED_RUNTIME_METHODS=cwrap --post-js=run.js"
```

### 4 Try It

Change to the published directory containing nativeaot-llvm-example.html and nativeaot-llvm-example.wasm. You'll need a web server - for example in python you can run:

```
python -m http.server
```

Then, browse to the page, for example:

```
http://localhost:8000/nativeaot-llvm-example.html
```

The console here should show '7' - 5, plus 1 added by the C function and 1 added by the C# wrapper around the C function.
