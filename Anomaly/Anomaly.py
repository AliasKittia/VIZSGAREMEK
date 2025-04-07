from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By

import time

# Böngésző indítása Brave-bal
brave_path = "C:/Program Files/BraveSoftware/Brave-Browser/Application/brave.exe"
options = webdriver.ChromeOptions()
options.binary_location = brave_path

driver = webdriver.Chrome(options=options)
driver.set_window_size(2040, 1680)

try:
    # Oldal betöltése
    driver.get("http://localhost:3000/anomalies")
    print("Oldal betöltve, várok 5 másodpercet...")
    time.sleep(5)  # Várakozás, hogy biztosan betöltődjön minden

    # Képernyőkép készítése
    driver.save_screenshot("alapbetoltes.png")
    print("Alapbetöltés screenshot kész!")

    # Keresés "Páncél" kifejezésre
    search_box = driver.find_element(By.ID, "search-input")  # ID alapján keresés
    search_box.send_keys("Páncél" + Keys.RETURN)
    print('"Páncél" keresése...')
    time.sleep(3)  # Várakozás az eredményekre
    driver.save_screenshot("pancel_kereses.png")
    print('Kész a "Páncél" screenshot!')

    # Keresés törlése és új keresés
    search_box.clear()
    search_box.send_keys("Valami" + Keys.RETURN)
    print('"Valami" keresése...')
    time.sleep(3)
    driver.save_screenshot("rossz_kereses.png")
    print('Kész a "Valami" screenshot!')

except Exception as e:
    print(f"Hiba történt: {e}")
    driver.save_screenshot("hiba.png")

finally:
    driver.quit()
    print("Böngésző bezárva.")