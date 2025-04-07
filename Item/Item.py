from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.common.action_chains import ActionChains
import time

# 1. Böngésző indítása
driver = webdriver.Chrome()
driver.get("http://localhost:3000/items")  # ← Cseréld ki a saját oldalad URL-jére
time.sleep(2)

# 📸 Első képernyőfotó - oldal betöltése
driver.save_screenshot("1_kereses_oldal_betoltve.png")

# 2. Keresőmező megkeresése és beírás (rossz keresés)
search = driver.find_element(By.ID, "search-filter")
search.send_keys("példa")
time.sleep(2)
driver.save_screenshot("2_rossz_kereses_utan.png")

# 3. Keresőmező törlése és új keresés
search.clear()
search.send_keys("is")
time.sleep(2)
driver.save_screenshot("3_jo_kereses_utan.png")

# 4. Hover az első találatra (feltételezzük class: card)
first_card = driver.find_element(By.CLASS_NAME, "card")
actions = ActionChains(driver)
actions.move_to_element(first_card).perform()
time.sleep(1)
driver.save_screenshot("4_hover_utan.png")

# 5. Böngésző bezárása
driver.quit()
