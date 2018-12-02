export const convertToFormData = (object) => {
  const formData = new FormData()
  Object.keys(object).forEach(key => formData.append(key, object[key]))
  return formData
}
