
function bodauTiengViet(str) {  
    str= str.toLowerCase();  
    str= str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g,"a");  
    str= str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g,"e");  
    str= str.replace(/ì|í|ị|ỉ|ĩ/g,"i");  
    str= str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g,"o");  
    str= str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g,"u");  
    str= str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g,"y");  
    str= str.replace(/đ/g,"d");  
    return str;  
}
function ChangeImage() {
    var value = $("#btnChonAnh").val().split("C:\\fakepath\\",2)
    $("#img").attr("src", "/Assets/Admin/images/" +value[1])
}

function MetaTitle_()
{
        var value = $("#Name").val().split(" ")
        var ans = ""
        for (var item in value) {
            ans += value[item]+"-"
        }
        ans=ans.substring(0,ans.length-1)
        $("#MetaTitle").val(bodauTiengViet(ans))

}