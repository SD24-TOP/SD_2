import pandas as pd
import numpy as np
import seaborn as sns
from sklearn.preprocessing import LabelEncoder
from scipy import stats
import matplotlib.pyplot as plt

def load_data():
    df = sns.load_dataset('mpg')
    print(df.info())
    return df

def summarize_numerical_vars(df):
    num_vars = df.select_dtypes(include=['float64', 'int64'])
    for column in num_vars.columns:
        missing_ratio = num_vars[column].isnull().sum()
        
        stats_info = {
            'max': num_vars[column].max(),
            'min': num_vars[column].min(),
            'mean': num_vars[column].mean(),
            'median': num_vars[column].median(),
            'variance': num_vars[column].var(),
            'quantile_0.1': num_vars[column].quantile(0.1),
            'quantile_0.9': num_vars[column].quantile(0.9),
            'quartile_1': num_vars[column].quantile(0.25),
            'quartile_3': num_vars[column].quantile(0.75)
        }

        print(f'Для {column}:')
        print(f'  Доля пропусков: {missing_ratio:.2f}')
        for key, value in stats_info.items():
            print(f'  {key}: {value}')

        if missing_ratio > 0:
            print("Заменим пустые значения на среднее арифметическое")    
            df[column] = df[column].fillna(df[column].mean())
            print(f"Доля пропусков для {column}: {num_vars[column].isnull().sum()}")

    return df

def summarize_categorical_vars(df):
    cat_vars = df.select_dtypes(include=['object'])
    le = LabelEncoder()
    for column in cat_vars.columns:
        missing_ratio = cat_vars[column].isnull().mean()
        unique_count = cat_vars[column].nunique()
        mode = cat_vars[column].mode()[0]

        print(f'Для {column}:')
        print(f'  Доля пропусков: {missing_ratio:.2f}')
        print(f'  Количество уникальных значений: {unique_count}')
        print(f'  Мода: {mode}')

        df[f'{column}_Code'] = le.fit_transform(df[column])
        df.drop(column, axis=1, inplace=True)

    return df

def test_hypothesis_1(df):
    mpg_4_cylinders = df[df['cylinders'] == 4]['mpg']
    mpg_6_cylinders = df[df['cylinders'] == 6]['mpg']

    t_stat, p_value = stats.ttest_ind(mpg_4_cylinders, mpg_6_cylinders)
    print("\nГипотеза 1. Соотношение среднего расхода у 4 и 6 цилиндров:") 
    print("t-статистика =", t_stat, ", p-значение =", p_value)
    print("Гипотеза верна" if p_value > 0.05 else "Гипотеза не верна")

def test_hypothesis_2(df):
    correlation, p_value = stats.pearsonr(df['mpg'], df['weight'])
    print("\nГипотеза 2. Проверка зависимости mpg от weight:")
    print("Коэффициент корреляции =", correlation, ", p-значение =", p_value)
    print("Гипотеза верна" if p_value > 0.05 else "Гипотеза не верна")

def test_hypothesis_3(df):
    correlation, p_value = stats.pearsonr(df['mpg'], df['horsepower'])
    print("\nГипотеза 3. Проверка зависимости mpg от horsepower:")
    print("Коэффициент корреляции =", correlation, ", p-значение =", p_value)
    print("Гипотеза верна" if p_value > 0.05 else "Гипотеза не верна")

def test_hypothesis_4(df):
    f_stat, p_value = stats.f_oneway(df[df['origin_Code'] == 0]['mpg'], 
                                      df[df['origin_Code'] == 1]['mpg'], 
                                      df[df['origin_Code'] == 2]['mpg'])
    print("\nГипотеза 4. Влияние страны производителя на расход топлива:")
    print("F-статистика =", f_stat, ", p-значение =", p_value)
    print("Гипотеза верна" if p_value > 0.05 else "Гипотеза не верна")

def plot_correlation_matrix(df):
    correlation_matrix = df.corr()
    plt.figure(figsize=(12, 10))
    sns.heatmap(correlation_matrix, annot=True, fmt=".2f", cmap='coolwarm', cbar=True, square=True)
    plt.title('Матрица корреляции', fontsize=18)
    plt.xticks(rotation=45)
    plt.yticks(rotation=45)
    plt.savefig("correlation.png")
    return correlation_matrix

def normalize_features(X):
    return (X - X.mean()) / X.std()

def gradient_descent(X, y, learning_rate=0.01, n_iterations=1000):
    m = len(y)
    theta = np.zeros((X.shape[1] + 1, 1))
    X_b = np.c_[np.ones((m, 1)), X]

    for iteration in range(n_iterations):
        gradients = 2/m * X_b.T.dot(X_b.dot(theta) - y.values.reshape(-1, 1))
        theta -= learning_rate * gradients

    return theta

def stochastic_gradient_descent(X, y, learning_rate=0.01, n_epochs=1000):
    m = len(y)
    theta = np.zeros((X.shape[1] + 1, 1))
    X_b = np.c_[np.ones((m, 1)), X]

    for epoch in range(n_epochs):
        for i in range(m):
            random_index = np.random.randint(m)
            xi = X_b[random_index:random_index + 1]
            yi = y.iloc[random_index:random_index + 1].values.reshape(-1, 1)
            gradients = 2 * xi.T.dot(xi.dot(theta) - yi)
            theta -= learning_rate * gradients

    return theta


df = load_data()
df = summarize_numerical_vars(df)
df = summarize_categorical_vars(df)

test_hypothesis_1(df)
test_hypothesis_2(df)
test_hypothesis_3(df)
test_hypothesis_4(df)

correlation_matrix = plot_correlation_matrix(df)
print("\nМатрица корреляции", correlation_matrix)

y = df['mpg']
X_horsepower = normalize_features(df[['horsepower']])
X_weight = normalize_features(df[['weight']])

theta_gd_horsepower = gradient_descent(X_horsepower, y)
theta_gd_weight = gradient_descent(X_weight, y)

theta_sgd_horsepower = stochastic_gradient_descent(X_horsepower, y)
theta_sgd_weight = stochastic_gradient_descent(X_weight, y)


print("\nОбычный градиентный спуск (horsepower):", theta_gd_horsepower)
print("Обычный градиентный спуск (weight):", theta_gd_weight)
print("Стохастический градиентный спуск (horsepower):", theta_sgd_horsepower)
print("Стохастический градиентный спуск (weight):", theta_sgd_weight)

