# Crear conjuntos de ciudadanos (simulados)
ciudadanos = set(range(1, 501))  # 500 ciudadanos
vacunados_con_pfizer = set(range(1, 76))  # 75 vacunados con Pfizer
vacunados_con_astra = set(range(20, 95))  # 75 vacunados con Astrazeneca

# Operaciones de conjuntos para obtener los distintos grupos de ciudadanos
no_vacunados = ciudadanos - vacunados_con_pfizer - vacunados_con_astra
vacunados_ambas = vacunados_con_pfizer & vacunados_con_astra
solo_pfizer = vacunados_con_pfizer - vacunados_con_astra
solo_astra = vacunados_con_astra - vacunados_con_pfizer

# Mostrar resultados por consola
print(f"Ciudadanos no vacunados: {len(no_vacunados)}")
print(f"Ciudadanos con ambas vacunas: {len(vacunados_ambas)}")
print(f"Ciudadanos solo con Pfizer: {len(solo_pfizer)}")
print(f"Ciudadanos solo con Astrazeneca: {len(solo_astra)}")

# Guardar el reporte en un archivo de texto
with open("reporte_vacunacion.txt", "w") as archivo:
    archivo.write("Reporte de Vacunación COVID-19\n")
    archivo.write(f"Ciudadanos no vacunados: {len(no_vacunados)}\n")
    archivo.write(f"Ciudadanos con ambas vacunas: {len(vacunados_ambas)}\n")
    archivo.write(f"Ciudadanos solo con Pfizer: {len(solo_pfizer)}\n")
    archivo.write(f"Ciudadanos solo con Astrazeneca: {len(solo_astra)}\n")
