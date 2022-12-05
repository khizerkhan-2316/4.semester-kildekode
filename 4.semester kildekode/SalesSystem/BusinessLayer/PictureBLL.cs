using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public class PictureBLL
	{

		private static PictureBLL instance;
		private readonly PictureRepository repository;


		private PictureBLL()
		{
			repository = new PictureRepository();
		}

		public static PictureBLL GetController()
		{

			if (instance == null)
			{
				instance = new PictureBLL();
			}

			return instance;
		}

		public void SavePicture(PictureDto picture)
		{
			Picture created = new Picture(picture.Title, picture.ImagePath);
			created.ImageFile = picture.ImageFile;
			created.PictureId = picture.PictureId;
			repository.InsertEntity(created);

		}

		public string GetImagePath(PictureDto picture)
		{
			string fileName = Path.GetFileNameWithoutExtension(picture.ImageFile.FileName);
			string extension = Path.GetExtension(picture.ImageFile.FileName);
			fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
			return fileName;

		}

		public PictureDto ModifyPicture(PictureDto picture)
		{
			picture.ImagePath = $"~/Images/{GetImagePath(picture)}";
			picture.Title = GetImageTitle(picture);
			picture.PictureId = Guid.NewGuid();
			return picture;
		}

		public string GetImageTitle(PictureDto picture)
		{
			return Path.GetFileNameWithoutExtension(picture.ImageFile.FileName);
		}

		public PictureDto GetDefaultImage()
		{
			return repository.GetDefaultImage();
		}

	}
}
