import requests
import json
import sys


API_KEY = "80930629d5af47608d252f65ac370407" 
API = "http://api.openweathermap.org/data/2.5/weather?units=metric&lat={lati}&lon={longi}&APPID={key}"
text = "{0}:{1}:{2}:{3}:{4}:{5}"

if __name__ == '__main__':
    if len(sys.argv) == 3:
        Lati = float(sys.argv[1])
        Longi = float(sys.argv[2])
        #Lati = 35.728941
        #Longi = 139.644784
        URL = API.format(lati= Lati, longi = Longi, key = API_KEY)

        response = requests.get(URL)
        data = response.json()
        if data['cod'] != '404': 
            town = data['name']
            main = data['weather'][0]['main']
            desc = data['weather'][0]['description']
            temp = data['main']['temp']
            maxm = data['main']['temp_max']
            minm = data['main']['temp_min']

            print (text.format(town, main, desc, temp, maxm, minm))
        else: 
            print ("Connection Error")
    else:
        print ("Argument Error")






