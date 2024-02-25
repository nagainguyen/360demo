document.addEventListener('DOMContentLoaded', function () {
    const apiUrl = '/api/Images/listImages';
    let dataList;

    async function getImagesAndDisplay() {
        try {
            const response = await fetch(apiUrl);
            if (!response.ok) {
                throw new Error(`Lỗi khi lấy dữ liệu: ${response.status} - ${response.statusText}`);
            }
            const { data } = await response.json();
            console.log(data);
            dataList = data.map(item => ({
                idScence: item.idScence,
                NAME: item.name,
                title: item.title,
                linkImage: item.linkImage,
                pitch: item.pitch,
                yaw: item.yaw
            }));

            displayImages(dataList);
            console.log(dataList);
        } catch (error) {
            console.error('Lỗi khi lấy danh sách ảnh từ API:', error);
        }
    }

    function displayImages(dataList) {
        const tableBody = document.querySelector('#ImageTable tbody');
        tableBody.innerHTML = '';

        dataList.forEach(data => {
            const row = document.createElement('tr');
            row.innerHTML = `
                <td>${data.idScence}</td>
                <td>${data.NAME}</td>
                <td>${data.title}</td>
                <td>${data.linkImage}</td>
                <td>${data.pitch}</td>
                <td>${data.yaw}</td>
                <td>
                    <button onclick="editImages('${data.idScence}')">Sửa</button>
                    <button onclick="confirmDelete('${data.idScence}')">Xóa</button>
                </td>
            `;
            tableBody.appendChild(row);
        });
    }

    document.getElementById('addDataForm').addEventListener('submit', async function (e) {
        e.preventDefault();

        const url = window.location.origin + '/api/Images/insertImage';

        const name = document.getElementById('nameInput').value;
        const Title = document.getElementById('idImageInput').value;
        const linkImage = document.getElementById('linkImageInput').value;
        const pitch = parseFloat(document.getElementById('pitchInput').value);
        const yaw = parseFloat(document.getElementById('yawInput').value);

        const dataToPost = {
            Name: name,
            title: Title,
            linkImage: linkImage,
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
                alert('Thêm ảnh mới thành công!');
                getImagesAndDisplay();

                // Clear textbox values
                document.getElementById('nameInput').value = '';
                document.getElementById('idImageInput').value = '';
                document.getElementById('linkImageInput').value = '';
                document.getElementById('pitchInput').value = '';
                document.getElementById('yawInput').value = '';
            } else {
                console.error('FAIL');
                alert('Thêm ảnh mới thất bại!');
            }
        } catch (error) {
            console.error('ERROR REQUEST:', error);
        }
    });

    // Xác nhận xóa
    window.confirmDelete = function (id) {
        const confirmResult = confirm('Bạn có chắc chắn muốn xóa ảnh này không?');
        if (confirmResult) {
            deleteImage(id);
        }
    };

    async function deleteImage(id) {
        const url = `/api/Images/deleteImage/${id}`;

        try {
            const response = await fetch(url, {
                method: 'DELETE',
            });

            if (response.ok) {
                console.log('SUCCESS');
                alert('Xóa ảnh thành công!');
                getImagesAndDisplay();
            } else {
                console.error('FAIL');
                alert('Xóa ảnh thất bại!');
            }
        } catch (error) {
            console.error('ERROR REQUEST:', error);
        }
    }
});
