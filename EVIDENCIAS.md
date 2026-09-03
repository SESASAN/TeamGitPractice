# Evidencias - Práctica 1 Git colaborativo

## Equipo: Deploy Enjoyers

| Integrante | Nombre completo | Rama personal | Commit consola | Commit Visual Studio | Pull Request | Reviewer |
|---|---|---|---|---|---|---|
| 1 | Sebastián Jesús Pérez Araujo | `sebastian-perez` | `21c770a` | `4ec8931f` | #2 | Samuel Quiroz Rincón |
| 2 | Kevin Daniel Mendoza Castillo | `kevin-mendoza` | `b6e6d19` | `a239770` | #5 | Sebastián Jesús Pérez Araujo |
| 3 | Juan Felipe Torres Torres | `juan-torres` | | | | |
| 4 | Nathalie Gabriela Miranda Rejón | `nathalie-miranda` | `ba82de4` | `13802a7` | #3 | Juan Felipe Torres Torres |
| 5 | Samuel Quiroz Rincón | `samuel-quiroz` | | | | |

## Resolución de conflicto (Fase 6)

- Pull Request donde se resolvió el conflicto:
- Hash del commit que resolvió el conflicto (`fix: resolve team message conflict`):
- Versión de Kevin (Integrante 2) en `TeamMessage.txt`:
- Versión de Juan (Integrante 3) en `TeamMessage.txt`:
- Texto final acordado:

## Recuperación de cambios (Fase 7)

- Evidencia de `git restore` (Integrante 4 - Nathalie):
Se modificó README.md agregando una línea de prueba, se verificó con git diff README.md,
y se descartó el cambio con git restore README.md. git status confirmó árbol de trabajo limpio.
- Evidencia de `git restore --staged` (Integrante 4 - Nathalie):
Se modificó README.md nuevamente, se agregó a staging con git add, se retiró congit restore --staged README.md (quedó como "modified, not staged"), y finalmente se descartó con git restore README.md.
- Hash del commit temporal `test: add temporary note` (Integrante 5 - Samuel):
- Hash del commit generado por `git revert` (Integrante 5 - Samuel):

## Capturas

- Captura de Git Changes (Visual Studio):
  <img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/ff54569b-891b-46e8-bb29-24fa457160ac" />
- Captura de Git Bash / terminal integrada:
  <img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/a07b0861-866a-4d24-948d-5713da646cf8" />

## Colaboradores

- [ ] Confirmación de que `oalarconpe` fue agregado como colaborador del repositorio.
