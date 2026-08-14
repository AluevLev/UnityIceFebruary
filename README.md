## 🧊 UnityIceFebruary

UnityIceFebruary is the production-ready high-performance binding and execution layer designed to connect the pure C# logic architecture of IceFebruary.Pure (POCO) with the Unity game engine.
While the core logic repository operates strictly within a pure C# memory space to maintain strict isolation and full testability, this repository acts as the bridge that materializes those abstract contracts in Unity. It maps POCO interfaces directly to Unity sub-components, routes native engine lifecycles (Update, FixedUpdate, and Destroy) to internal logical loops, and provides an advanced compile-time code-generation pipeline coupled with layout tools for non-technical designer setup.

------------------------------

## ✨ Architectural Highlights & Features

* Strict Framework Separation: Preserves a fully isolated domain model on the pure C# layer while seamlessly interacting with UnityEngine objects.
* Reinterpretation Optimization: Bypasses garbage collection layout spikes by mapping underlying animator values using System.Runtime.CompilerServices.Unsafe raw pointer reinterpretation.
* Dynamic Non-Alloc Physics Scaling: Hosts an adaptive environmental overlap buffer cache that resizes gracefully by computing optimal powers-of-two layouts, eliminating dropped frames under dense environmental queries.
* Polymorphic SerializeReference Dropdowns: Extends the Unity inspector to support abstract interface instantiation and deep structural data layout fields right out of the box.
* Compile-Time Meta-Generation: Utilizes runtime assembly reflection to scan source contracts and emit serialized components, asset menus, and routing dictionaries automatically.

------------------------------

## 🛠 Runtime & Interface Mapping Subsystems## 1. The Execution Clock (UnityBaseGameAssembler)

Acts as the heartbeat that hooks the isolated logic core directly into Unity's frame updating pipeline:

* Inherits from MonoBehaviour to capture standard hardware frame update cycles.
* Translates native engine updates into explicit delta steps for the decoupled core time loop via _innerAssembler.Time.DoFrame(Time.deltaTime) and DoFixedFrame().
* Standardizes initialization layouts (Assemble()) and graceful application teardowns (Disassemble()).

## 2. High-Speed Object Parity tracking (UnityMethods & UnityBaseEntity)

* UnityBaseEntity<T>: An abstract baseline model connecting a plain C# model to an active engine target instance (where T : UnityEngine.Object). Altering the Enabled parameter routes instructions through a optimized toggling engine (UnityToggler) to immediately handle active physics rigidbodies, particles, renderers, and behavioral switches.
* UnityMethods.Upsert: Implements ultra-fast type caching powered by a ConditionalWeakTable. This allows the framework to either fetch an existing wrapped instance from a central registry or safely invoke its corresponding factory delegate without causing double-allocation artifacts.

## 3. Native Environment Queries (UnityPhysics2D & UnityTime)

* UnityPhysics2D Overlaps: Acts as a direct translation proxy for geometric primitives (IShape). Pure geometric definitions (Circle, Rectangle, Dot) are mapped onto OverlapCircle, OverlapBox, and OverlapPoint operations.
* Buffer Allocation Protections: Queries are executed in a zero-allocation NonAlloc mode using a local array layout (_collidersBuffer). If target intersections exceed capacity, the system evaluates the nearest power-of-two allocation boundaries using Math.GetPower2WithReserve, expanding the array dynamically before executing a safe recursive pass.
* UnityTime Clock Mapping: Proxiers spatial runtime clock statistics (Time.time and Time.fixedDeltaTime) directly down to the internal EntityFastArray<T> tracking arrays.

## 4. Low-Level Component Performance Bridges

* UnityAnimator: Routes layout parameter updates strictly through string hash values. To prevent generic boxing and unboxing memory allocations, the system leverages Unsafe.As<TFrom, TTo> reference reinterpretation to query and assign variables instantly.
* UnityTransform & UnityRigidbody2D: Manages layout positions, scales, and rotational transformations. It safely maps flat, complex 2D Rotor2 structures into Unity's multi-axis Quaternion layout (binding to the necessary Z and W dimensions), while forwarding physical force distributions (AddForce, AddTorque) via swift enum casting.
* UnityHingeJoint2D & UnityCamera: Bridges coordinate conversion workflows (ScreenToWorldPoint/WorldToScreenPoint) and connects active joint bounds across separate runtime components.

------------------------------

## 🧩 Advanced Inspector & Visual Workflow Automation

The bridge incorporates specialized tools that allow non-technical game designers to manipulate complex POCO structures visually inside the Unity inspector layout. To keep retail game builds lean, all workflow automation components are isolated behind standard #if UNITY_EDITOR preprocessor conditional flags, ensuring zero performance impact on final compilation.

## 1. The Unity Compilation Generator (ProxyGenerator)

To remove manual component wiring, the project features a compile-time code automation engine accessible via the Tools/Generate scripts editor menu layout. It executes the following structural parsing routine:

   1. Reflection Scan: Loads the primary Assembly-CSharp workspace assembly file and extracts all declared types, discarding elements already carrying the AUTOGENERATED mark.
   2. Prioritization Check: Groups contracts using priority heuristics, analyzing components decorated with [InterfaceProxy] first to resolve dependent structural chains.
   3. Constructor Inspection: Inspects available constructors via GetParameters() to automatically output serialized class properties mapped with an underscore prefix (_fieldName).
   4. Code Emission: Compiles raw string buffers via ProxyCodeBuilder and routes files into the targeted Assets/Auto Generated/ folder structure:

```text
Assets/Auto Generated/
├── Interface Proxy/       # Mapped interfaces providing ToPoco() translation utilities
├── Field Proxy/           # Serialized components with built-in reference hooks
├── Data Object Proxy/     # ScriptableObject script files equipped with [CreateAssetMenu] hooks
├── Proxy/                 # Configuration classes inheriting from UnityInfo and IRootConfig
├── Generic Variant Proxy/ # Specialized wrappers automatically generated for generic types
└── Static Dictionaries/   # Houses UnityMatchObject and static factory reference mappings
```

## 2. Interface Polymorphism plugin (InterfaceImplementation)

Unity’s standard inspector lacks intuitive support for working with interfaces directly through [SerializeReference]. This sub-system remedies the limitation via a custom property plugin setup:

* [InterfaceImplementation]: A structural property attribute applied directly to reference array positions or object properties.
* InterfaceImplementationDrawer: A custom property drawer that replaces the generic type input text field with an organized context dropdown menu (GenericMenu). It reflects across the current AppDomain to parse all compatible, non-abstract classes extending the targeted interface, dynamically implementing generic parameters via MakeGenericType on the fly.
* Visual Rendering Loops: Converts complex parameter signatures into human-readable representations (e.g., displaying MyGeneric<Int32>). When selected, the drawer invokes Activator.CreateInstance, securely updates properties via the standard Undo framework, and recursively evaluates layouts using custom GetPropertyHeight routines to draw inner child properties with correct foldouts and indentation tracking.

## 3. Integrated Conversion Windows

* Angle to Rotor Converter: A custom EditorWindow utility that converts standard degree value inputs into the core system's mathematical Rotor2 complex dimensions, outputting the exact numeric Scalar and XY bivector fields.
* Animator Name to Hash Converter: Provides an in-editor string utility that takes human-readable text configurations and instantly maps them to strict integer identifier hashes via Animator.StringToHash, ensuring developers never copy-paste names manually.
* Layer Mask to Int Converter: Converts typical dropdown check-box layer arrangements into the exact numerical integer bitmask parameters consumed by the POCO physics core scanners.

## 4. Wireframe Visualization (UnityDrawer)

A hardware-friendly visual debugging assistant designed to render abstract logical objects right inside the scene editor window:

* Pre-cached Trigonometric Coordinates: To render fluid radial outlines, the utility completely removes runtime sine/cosine calculations from the update loop, matching outlines against a flat array of thirty-six pre-calculated vector points.
* Polymorphic Geometry Drawing: Inspects core IShape logic structures and draws precise green bounding wires, wireframe rings, or custom intersection marker vectors safely inside the scene editor view.

------------------------------

## 🎮 Production & Examples

This bridge repository is designed to be paired directly with the core logic layer. To see a production-ready example of how developers write gameplay code, configure design-ready assets, and orchestrate the engine's update cycle using this architecture, check out the full reference implementation:

* 🚀 **[https://github.com/AluevLev/FightForStick]** — A complete production-ready project built entirely on top of the IceFebruary architectural framework.

------------------------------

## ⚙️ Technical Requirements

* Language Specification: C# 9.0+ / Unsafe Code block processing enabled.
* Host Engine Target: Unity LTS releases (full compatibility with modern runtime compilation standards).
* Dependencies: Requires the core companion IceFebruary.Pure assembly reference package inside your project folder layout.