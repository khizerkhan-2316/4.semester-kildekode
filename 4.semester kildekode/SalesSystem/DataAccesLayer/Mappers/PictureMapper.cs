using DataAccessLayer.Model;
using DataTransferObjects.Models;

namespace DataAccessLayer.Mappers
{
	public class PictureMapper
	{

		public PictureDto Map(Picture picture)
		{
			PictureDto dto = new PictureDto(picture.Title, picture.ImagePath);
			dto.PictureId = picture.PictureId;

			return dto;
		}
	}
}
