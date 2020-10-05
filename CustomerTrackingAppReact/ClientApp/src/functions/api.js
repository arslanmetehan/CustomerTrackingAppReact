export async function apiGET(url)
{
    const rawResponse = await fetch(url, {
        method: 'get',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        }
    });

    const response = await rawResponse.json();
    return response;
}
export async function apiPOST(url,data) {
    const rawResponse = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
             'Accept': 'application/json'
        },
        body: JSON.stringify(data)
    });

    const response = await rawResponse.json();
    return response;
}