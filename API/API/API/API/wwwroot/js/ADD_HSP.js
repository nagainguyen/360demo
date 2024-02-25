document.addEventListener('DOMContentLoaded', function () {
    const apiUrl = '/api/HotSpots/listHotSpots';
    let dataList;

    async function getHotSpotsAndDisplay() {
        try {
            const response = await fetch(apiUrl);
            if (!response.ok) {
                throw new Error(`Lỗi khi lấy dữ liệu: ${response.status} - ${response.statusText}`);
            }
            const { data } = await response.json();
            console.log(data);
            dataList = data.map(item => ({
                idHsp: item.idHsp,
                NameScene: item.nameScene,
                NameNextScene: item.nameNextScene,
                Text: item.text,
                pitch: item.pitch,
                yaw: item.yaw
            }));

            displayHotSpots(dataList);
            console.log(dataList);
        } catch (error) {
            console.error('Lỗi khi lấy danh sách hotspots từ API:', error);
        }
    }

    function displayHotSpots(dataList) {
        const tableBody = document.querySelector('#HotSpotTable tbody');
        tableBody.innerHTML = '';

        dataList.forEach(data => {
            const row = document.createElement('tr');
            row.innerHTML = `
                <td>${data.idHsp}</td>
                <td>${data.NameScene}</td>
                <td>${data.NameNextScene}</td>
                <td>${data.Text}</td>
                <td>${data.pitch}</td>
                <td>${data.yaw}</td>
                <td>
                    <button onclick="editHotSpots('${data.idHsp}')">Sửa</button>
                    <button onclick="confirmDelete('${data.idHsp}')">Xóa</button>
                </td>
            `;
            tableBody.appendChild(row);
        });
    }

    document.getElementById('addDataFormHSP').addEventListener('submit', async function (e) {
        e.preventDefault();
        const url = window.location.origin + '/api/HotSpots/insertHotSpot';

        const IDScence = document.getElementById('InputIDScence').value;
        const IDNextScence = document.getElementById('InputIDNextScence').value;
        const text = document.getElementById('InputText').value;
        const pitch = parseFloat(document.getElementById('pitchInput').value);
        const yaw = parseFloat(document.getElementById('yawInput').value);

        const dataToPost = {
            NameScene: IDScence,
            NameNextScene: IDNextScence,
            Text: text,
            pitch: pitch,
            yaw: yaw
        };

        try {
            const response = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(dataToPost),
            });

            if (response.ok) {
                console.log('SUCCESS');
                alert('Thêm hotspot mới thành công!');
                getHotSpotsAndDisplay();

                // Clear textbox values
                document.getElementById('InputIDScence').value = '';
                document.getElementById('InputIDNextScence').value = '';
                document.getElementById('InputText').value = '';
                document.getElementById('pitchInput').value = '';
                document.getElementById('yawInput').value = '';
            } else {
                console.error('FAIL');
                alert('Thêm hotspot mới thất bại!');
            }
        } catch (error) {
            console.error('ERROR REQUEST:', error);
        }
    });

    // Xác nhận xóa
    window.confirmDelete = function (id) {
        const confirmResult = confirm('Bạn có chắc chắn muốn xóa hotspot này không?');
        if (confirmResult) {
            deleteHotSpot(id);
        }
    };

    async function deleteHotSpot(id) {
        const url = `/api/HotSpots/deleteHotSpot/${id}`;

        try {
            const response = await fetch(url, {
                method: 'DELETE',
            });

            if (response.ok) {
                console.log('SUCCESS');
                alert('Xóa hotspot thành công!');
                getHotSpotsAndDisplay();
            } else {
                console.error('FAIL');
                alert('Xóa hotspot thất bại!');
            }
        } catch (error) {
            console.error('ERROR REQUEST:', error);
        }
    }
});
