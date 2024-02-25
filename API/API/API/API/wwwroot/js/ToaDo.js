
function handleSearchInput(searchTerm) {
    console.log('Search Term: ' + searchTerm);
    //viet chuc nang tim kiem trong nay
}

var pitch, yaw, hfov;

window.addEventListener('DOMContentLoaded', function () {
    var panorama = pannellum.viewer('panorama', {
        "type": "equirectangular",
        "panorama": "./Image/river.jpg",
        "autoLoad": true,
    });
    panorama.on('rightclick', function (e) {

        var hfov1 = panorama.getConfig().hfov;
        var horizontalFov = 2 * Math.atan(Math.tan(hfov1 * (Math.PI / 180) / 2) * (panoramaWidth / panoramaHeight)) * (180 / Math.PI);
        hfov = horizontalFov;
        console.log('HFOV: ' + hfov.toFixed(2)); 
    });
    panorama.getContainer().addEventListener('contextmenu', function (e) {
        e.preventDefault();
        var mouseX, mouseY;

        if (e.mouseEvent) {
            mouseX = e.mouseEvent.clientX;
            mouseY = e.mouseEvent.clientY;
        } else if (window.event) {
            mouseX = window.event.clientX;
            mouseY = window.event.clientY;
        }

        if (mouseX !== undefined && mouseY !== undefined) {
            var panoramaWidth = panorama.getContainer().clientWidth;
            var panoramaHeight = panorama.getContainer().clientHeight;
            pitch = (mouseY / panoramaHeight) * 180 - 90;
            yaw = (mouseX / panoramaWidth) * 360 - 180;

            console.log('Pitch: ' + pitch.toFixed(2) + ' Yaw: ' + yaw.toFixed(2));

            panorama.addHotSpot({
                "hfov": hfov,
                "pitch": pitch,
                "yaw": yaw,
                "cssClass": "custom-hotspot",
                "createTooltipFunc": function (div, args) {
                    var searchBox = document.createElement('input');
                    searchBox.setAttribute('type', 'text');
                    searchBox.setAttribute('placeholder', 'Tìm kiếm...');
                    searchBox.addEventListener('contextmenu', function (e) {
                        e.stopPropagation();
                    });
                    searchBox.addEventListener('keydown', function (e) {
                        if (e.key === 'Enter') {
                            var searchTerm = searchBox.value;
                            searchBox.style.display = 'none';
                            handleSearchInput(searchTerm);
                        }
                    });

                    div.appendChild(searchBox);
                }
            });
        } else {
            console.log('Không thể lấy thông tin sự kiện chuột.');
        }
    });
});
