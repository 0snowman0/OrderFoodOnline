from geopy.geocoders import Nominatim
from flask import Flask, request

# create an instance of the Flask application
app = Flask(__name__)

# calling the Nominatim tool
loc = Nominatim(user_agent="GetLoc")

# entering the location name
getLoc = loc.geocode("Gosainganj Lucknow")

# route for retrieving location information
@app.route('/api/Location', methods=['Get'])
def addJson():
    # return JSON object with location information
    return {
        'Latitude': getLoc.latitude,
        'Longitude': getLoc.longitude
    }

if __name__ == "__main__":
    app.run(debug=True)


#run with this url : http://localhost:5000/api/location