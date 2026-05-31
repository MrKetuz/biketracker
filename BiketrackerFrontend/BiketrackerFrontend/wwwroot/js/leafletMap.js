namespace BiketrackerFrontend.wwwroot.js
{
    public class leafletMap
    {

        console.log("leafletMap.js loaded");

        window.leafletMap = {
            init: function (id, lat, lng, zoom) {
                console.log("init called");
            }
        };

        window.leafletMap = {
            map: null,
            path: null,
            currentMarker: null,

            init: function (id, lat, lng, zoom) {
                this.map = L.map(id).setView([lat, lng], zoom);

                L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
                    attribution: "&copy; OpenStreetMap"
                }).addTo(this.map);
            },

            render: function (points, current) {

                // remove old path
                if (this.path) {
                    this.map.removeLayer(this.path);
                }

                const latlngs = points.map(p => [p.lat, p.lng]);

                this.path = L.polyline(latlngs, { color: "blue", weight: 4 })
                    .addTo(this.map);

                // current position marker
                if (this.currentMarker) {
                    this.map.removeLayer(this.currentMarker);
                }

                this.currentMarker = L.marker([current.lat, current.lng])
                    .addTo(this.map);

                if (latlngs.length > 0) {
                    this.map.fitBounds(this.path.getBounds(), {
                        padding: [20, 20]
                    });
                }
            }
        };

    }
}
