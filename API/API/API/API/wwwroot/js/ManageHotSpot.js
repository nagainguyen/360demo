const apiUrl = '/api/HotSpots/listHotSpots';
let dataList; 

document.addEventListener('DOMContentLoaded', function () {
    getImagesAndDisplay();

    async function getImagesAndDisplay() {
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

            displayImages(dataList);
            console.log(dataList);
        } catch (error) {
            console.error('Lỗi khi lấy danh sách ảnh từ API:', error);
        }
    }

    function displayImages(dataList) {
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
                    <button onclick="editImages('${data.idHsp}')">Sửa</button>
                    <button onclick="confirmDelete('${data.idHsp}')">Xóa</button>
                </td>
            `;
            tableBody.appendChild(row);
        });
    }

    window.confirmDelete = function (idHsp) {
        const shouldDelete = confirm('Bạn có chắc muốn xóa ảnh này không?');
        if (shouldDelete) {
            console.log('ID trước khi xóa:', idHsp);
            deleteImage(idHsp);
        }
    };

    async function deleteImage(idHsp) {
        console.log('ID trong hàm deleteImage:', idHsp);
        const deleteUrl = `/api/HotSpots/Delete?idHsp=${idHsp}`;

        try {
            const response = await fetch(deleteUrl, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (!response.ok) {
                throw new Error(`Lỗi khi xóa ảnh: ${response.status} - ${response.statusText}`);
            }

            getImagesAndDisplay();
        } catch (error) {
            console.error('Lỗi khi xóa ảnh:', error);
        }
    }

    window.editImages = function (idHsp) {
        openEditModal(idHsp);
    };

    function openEditModal(idHsp) {
        const editModal = document.getElementById('editTable');
        if (editModal.style.display === 'none') {
            editModal.style.display = 'table'; 
        } else {
            editModal.style.display = 'none'; 
        }

     
        const dataToEdit = dataList.find(item => item.idHsp === idHsp);
        document.getElementById('editIdHsp').value = idHsp;
        document.getElementById('editNameScene').value = dataToEdit.NameScene;
        document.getElementById('editNameNextScene').value = dataToEdit.NameNextScene;
        document.getElementById('editText').value = dataToEdit.Text;
        document.getElementById('editPitch').value = dataToEdit.pitch;
        document.getElementById('editYaw').value = dataToEdit.yaw;
    }

    document.getElementById('saveChangesBtn').addEventListener('click', saveChanges);

    function saveChanges() {
        const editedIdHsp = document.getElementById('editIdHsp').value;
        const editedNameScene = document.getElementById('editNameScene').value;
        const editedNameNextScene = document.getElementById('editNameNextScene').value;
        const editedText = document.getElementById('editText').value;
        const editedPitch = parseFloat(document.getElementById('editPitch').value);
        const editedYaw = parseFloat(document.getElementById('editYaw').value);

        const updateUrl = `/api/HotSpots/updateHotSpot`;

        const dataToUpdate = {
            idHsp: editedIdHsp,
            NameScene: editedNameScene,
            NamenextScene: editedNameNextScene,
            Text: editedText,
            pitch: editedPitch,
            yaw: editedYaw
        };

        fetch(updateUrl, {
            method: 'POST', 
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(dataToUpdate),
        })
            .then(response => {
                if (response.ok) {
                    console.log('SUCCESS');
                    alert('Cập nhật thành công!');
                    closeEditModal();
                    getImagesAndDisplay();
                } else {
                    console.error('FAIL');
                    alert('Cập nhật thất bại!');
                }
            })
            .catch(error => {
                console.error('ERROR REQUEST:', error);
            });
    }

    function closeEditModal() {
        const editTable = document.getElementById('editTable');
        editTable.style.display = 'none';
    }
});
