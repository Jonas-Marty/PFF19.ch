export const convertToFormData = object => {
    const formData = new FormData()
    Object.keys(object).forEach(key => formData.append(key, object[key]))
    return formData
}

// "2019-01-06T22:22:46"
export const convertStrintToDate = string => {
    const tempDateTime = string.split('-')
    return new Date(tempDateTime[0], tempDateTime[1] - 1, tempDateTime[2].split('T')[0])
}
