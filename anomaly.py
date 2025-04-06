from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
import time
brave_path = "C:/Program Files/BraveSoftware/Brave-Browser/Application/brave.exe"

options = webdriver.ChromeOptions()
options.binary_location = brave_path

driver = webdriver.Chrome(options=options)

driver.set_window_size(1920, 1080)
driver.get("http://localhost:3000/anomalies")
driver.save_screenshot("Alapbetoltes.png")
time.sleep(5)

search_box = driver.find_element(By.ID, "search-filter")
search_box.send_keys("Páncél")  
search_box.send_keys(Keys.RETURN)  
driver.save_screenshot("SearchPancel.png")
time.sleep(5)

search_box = driver.find_element(By.ID, "search-filter")
search_box.clear()  # érdemes törölni az előző keresést
search_box.send_keys("Valami")  
search_box.send_keys(Keys.RETURN)  
driver.save_screenshot("Rossz.png")
time.sleep(5)

driver.quit()
