const apiUrl = '/api/Images/listImages';
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


    window.confirmDelete = function (idScence) {
        const shouldDelete = confirm('Bạn có chắc muốn xóa ảnh này không?');
        if (shouldDelete) {
            console.log('ID trước khi xóa:', idScence);
            deleteImage(idScence);
        }
    };

    async function deleteImage(idScence) {
        console.log('ID trong hàm deleteImage:', idScence);
        const deleteUrl = `/api/Images/Delete?idScence=${idScence}`;

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

    window.editImages = function (idScence) {
        openEditModal(idScence);
    };

    function openEditModal(idScence) {
        const editModal = document.getElementById('editTable');
        if (editModal.style.display === 'none') {
            editModal.style.display = 'table';
        } else {
            editModal.style.display = 'none';
        }

        
        const dataEdit = dataList.find(item => item.idScence === idScence);
        document.getElementById('editIdScene').value = idScence;
        document.getElementById('editNameScene').value = dataEdit.NAME;
        document.getElementById('editTitle').value = dataEdit.title;
        document.getElementById('editLink').value = dataEdit.linkImage;
        document.getElementById('editPitch').value = dataEdit.pitch;
        document.getElementById('editYaw').value = dataEdit.yaw;
        console.log('data edit');
        console.log(dataToEdit);

    }

    document.getElementById('saveChangesBtn').addEventListener('click', saveChanges);

    function saveChanges() {
        const editedIdScene = document.getElementById('editIdScene').value;
        const editedNameScene = document.getElementById('editNameScene').value;
        const editedTitle = document.getElementById('editTitle').value;
        const editedLink = document.getElementById('editLink').value;
        const editedPitch = parseFloat(document.getElementById('editPitch').value);
        const editedYaw = parseFloat(document.getElementById('editYaw').value);
        console.log(editedLink);
        const updateUrl = `/api/Images/updateImage`;

        const dataToUpdate = {
            idScence: editedIdScene,
            Name: editedNameScene,
            Title: editedTitle,
            linkImage: editedLink,
            pitch: editedPitch,
            yaw: editedYaw
        };
        console.log("data update")
        console.log(dataToUpdate);
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