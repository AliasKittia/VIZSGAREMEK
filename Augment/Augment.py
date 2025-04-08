from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.common.action_chains import ActionChains
import time

# 1. Böngésző elindítása
driver = webdriver.Chrome()
driver.get("http://localhost:3000/augments") 
time.sleep(2)  # Várunk kicsit, hogy minden betöltődjön

driver.save_screenshot("1_oldal_betoltes.png")

# 2. Keresés (id: augment-search)
search = driver.find_element(By.ID, "augment-search")
search.send_keys("akadémiai")
time.sleep(1)
driver.save_screenshot("2_kereses_utan.png")

# 3. Szűrés kiválasztása (id: augment-filter)
dropdown = driver.find_element(By.ID, "augment-filter")
dropdown.click()
time.sleep(1)
dropdown.find_element(By.XPATH, "//option[text()='Arany']").click()
time.sleep(2)
driver.save_screenshot("3_szures_utan.png")

# 4. Hover az első kártyára (feltételezzük, hogy class: card)
first_card = driver.find_element(By.CLASS_NAME, "card")
actions = ActionChains(driver)
actions.move_to_element(first_card).perform()
time.sleep(1)
driver.save_screenshot("4_hover_utan.png")

# 5. Befejezés előtt várunk picit
time.sleep(2)
driver.quit()
