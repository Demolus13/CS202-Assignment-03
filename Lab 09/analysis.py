import json
import networkx as nx
from collections import defaultdict

def load_dependencies(json_file):
    with open(json_file, 'r') as f:
        data = json.load(f)
    return data

def build_dependency_graph(dependencies):
    G = nx.DiGraph()
    fan_in = defaultdict(int)
    fan_out = defaultdict(int)
    
    for module, deps in dependencies.items():
        for dep in deps:
            G.add_edge(dep, module)
            fan_out[module] += 1
            fan_in[dep] += 1
    
    return G, fan_in, fan_out

def analyze_coupling(fan_in, fan_out):
    all_modules = sorted(set(fan_in.keys()).union(set(fan_out.keys())))
    print("Highly Coupled Modules:")
    print("{:<50} | {:<10} | {:<10}".format("Module", "Fan-in", "Fan-out"))
    print("-" * 75)
    for module in all_modules:
        print("{:<50} | {:<10} | {:<10}".format(module, fan_in.get(module, 0), fan_out.get(module, 0)))

def detect_cycles(G):
    try:
        cycles = list(nx.simple_cycles(G))
        if cycles:
            print("Cyclic Dependencies Detected:")
            for cycle in cycles:
                print(" -> ".join(cycle))
        else:
            print("No cyclic dependencies found.")
    except Exception as e:
        print("Error detecting cycles:", e)

def find_disconnected_modules(G):
    disconnected = [node for node in G.nodes if G.in_degree(node) == 0 and G.out_degree(node) == 0]
    if disconnected:
        print("Unused/Disconnected Modules:", disconnected)
    else:
        print("No unused modules detected.")

def dependency_depth(G):
    if len(G.nodes) == 0:
        print("Graph is empty.")
        return
    depths = {node: nx.single_source_shortest_path_length(G, node) for node in G.nodes}
    max_depth = max(max(depth.values(), default=0) for depth in depths.values())
    print(f"Maximum Dependency Depth: {max_depth}")

def identify_core_module(fan_in):
    if not fan_in:
        return None
    return max(fan_in, key=fan_in.get)

def impact_analysis(G, core_module):
    if core_module not in G:
        print(f"Module {core_module} not found in dependencies.")
        return
    
    affected_modules = nx.descendants(G, core_module)
    risky_modules = [mod for mod in affected_modules if G.in_degree(mod) > 4]
    
    print(f"Changes in {core_module} affect {len(affected_modules)} modules:", affected_modules)
    print(f"Risky Modules (high impact if modified) ({len(risky_modules)}):", risky_modules)

if __name__ == "__main__":
    json_path = "dependencies.json"
    dependencies = load_dependencies(json_path)
    G, fan_in, fan_out = build_dependency_graph(dependencies)
    
    analyze_coupling(fan_in, fan_out)
    detect_cycles(G)
    find_disconnected_modules(G)
    dependency_depth(G)
    
    core_module = identify_core_module(fan_in)
    if core_module:
        print(f"Identified Core Module: {core_module}")
        impact_analysis(G, core_module)
    else:
        print("No core module identified.")
