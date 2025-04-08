import pandas as pd
from tabulate import tabulate

# Load the CSV file containing the LCOM metrics
csv_file = "lcom_analysis/TypeMetrics.csv"
df = pd.read_csv(csv_file)

metrics = ["LCOM1", "LCOM2", "LCOM3", "LCOM4", "LCOM5", "YALCOM"]

# Loop over each metric, sort descending, and display top 5 classes
for metric in metrics:
    print(f"\nTop 5 Classes for {metric}:")
    top_df = df.sort_values(by=metric, ascending=False).head(5)
    # Select key columns to display
    table = top_df[["Project Name", "Package Name", "Type Name", metric]]
    print(tabulate(table, headers='keys', tablefmt='pretty', showindex=False))
